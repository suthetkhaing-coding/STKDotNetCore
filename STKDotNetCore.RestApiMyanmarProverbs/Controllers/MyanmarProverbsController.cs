using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace STKDotNetCore.RestApiMyanmarProverbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<MyanmarProverb> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<MyanmarProverb>(jsonStr);
            return model;
        }

        [HttpGet("titles")]
        public async Task<IActionResult> Titles()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("proverbs")]
        public async Task<IActionResult> Proverbs()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs);
        }

        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult> Proverb(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            var proverb = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);

            if (proverb is null)
            {
                return NotFound("No proverb found.");
            }

            return Ok(proverb);
        }
    }


    public class MyanmarProverb
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_Mmproverbs
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }

}
