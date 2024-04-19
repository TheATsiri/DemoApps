using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumerLibrary.Models
{
    public class ComicModel
    {
        // the name of the properties corrrespond the properties of the api
        //
        // https://xkcd.com/info.0.json
        // {
        //  "month": "4",
        //  "num": 2921,
        //  "link": "",
        //  "year": "2024",
        //  "news": "",
        //  "safe_title": "Eclipse Path Maps",
        //  "transcript": "",
        //  "alt": "Okay, this eclipse will only be visible from the Arctic in February 2063, when the sun is below the horizon, BUT if we get lucky and a gigantic chasm opens in the Earth in just the right spot...",
        //  "img": "https://imgs.xkcd.com/comics/eclipse_path_maps.png",
        //  "title": "Eclipse Path Maps",
        //  "day": "17"
        //  }

        public int Num { get; set; }
        public string Img { get; set; }
    }
}
