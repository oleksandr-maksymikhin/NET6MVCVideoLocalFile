using Microsoft.AspNetCore.Mvc;

namespace NET6MVCVideoLocalFile.Controllers
{
    public class VideoController : Controller
    {
        private readonly string videoFilePath = "D:\\Education\\Step\\0_urgent\\20221110_Pictures_ForHolywoodService\\Interstellar.mp4"; // Replace with the actual path to your video file.

        // GET: Video/Get View with <video> that call the method - ActionResult GetVideo()
        public IActionResult VideoPlayer()
        {
            return View();
        }

        public ActionResult GetVideo()
        {
            try
            {
                var stream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);
                //// return status code 200
                //var response = new FileStreamResult(stream, "video/mp4");
                //// return status code 206
                var response = File(stream, "video/mp4", enableRangeProcessing: true);
                return response;
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log the error or return a custom error view.
                return View("Error");
            }
        }
    }
}
