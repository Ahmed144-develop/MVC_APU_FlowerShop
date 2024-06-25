using Microsoft.AspNetCore.Mvc;
using Amazon; //for linking your AWS account
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration; //appsettings.json section
using System.IO; // input output
using Microsoft.AspNetCore.Http;

namespace MVC_APU_FlowerShop2023.Controllers
{
    public class ImageUploadController : Controller
    {
        private const string s3BucketName = "mvcflowershoplab14";

        //function 1: connection string to the AWS Account
        private List<string> getValues()
        {
            List<string> values = new List<string>();

            //1. link to appsettings.json and get back the values
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build(); //build the json file

            //2. read the info from json using configure instance
            values.Add(configure["Values:Key1"]);
            values.Add(configure["Values:Key2"]);
            values.Add(configure["Values:Key3"]);

            return values;
        }

        //function 2: Upload image to S3 and generate the URL and store to DB
        // ...

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessUploadImage(List<IFormFile> imagefile)
        {
            //1. add credential for action
            List<string> values = getValues();
            var awsS3client = new AmazonS3Client(values[0], values[1], values[2], RegionEndpoint.USEast1);

            //2. read image by image and store to S3
            foreach (var image in imagefile)
            {
                if (image.Length <= 0)
                {
                    return BadRequest("It is an empty file. Unable to upload!");
                }
                else if (image.Length > 1048576) //not more than 1MB
                {
                    return BadRequest("It is over 1MB limit of size. Unable to upload!");
                }
                else if (image.ContentType.ToLower() != "image/png" && image.ContentType.ToLower() != "image/jpeg"
                    && image.ContentType.ToLower() != "image/gif")
                {
                    return BadRequest("It is not a valid image! Unable to upload!");
                }

                //3. upload image to S3 and get the URL
                try
                {
                    //upload to S3
                    PutObjectRequest uploadRequest = new PutObjectRequest //generate the request
                    {
                        InputStream = image.OpenReadStream(),
                        BucketName = s3BucketName + "/images",
                        Key = image.FileName,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    //send out the request
                    await awsS3client.PutObjectAsync(uploadRequest);
                }
                catch (AmazonS3Exception ex)
                {
                    return BadRequest("Unable to upload to S3 due to technical issue. Error message: " + ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest("Unable to upload to S3 due to technical issue. Error message: " + ex.Message);
                }
            }

            //4. return to Upload page again
            return RedirectToAction("Index", "ImageUpload");
        }

        // ...

        public IActionResult Index()
        {
            return View();
        }
    }
}
