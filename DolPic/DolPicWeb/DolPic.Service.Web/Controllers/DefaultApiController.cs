using DolPic.Service.Web.Common;
using DolPic.Service.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DolPic.Service.Web.Controllers
{
    public class DefaultApiController : CustomApiController
    {

        // GET api/default1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/default1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/default1
        public HttpResponseMessage PostDefaultApi(HsahTag item)
        {
            log.DebugFormat("ImageSrc == {0}", item.ImageSrc);
            log.DebugFormat("TagNo == {0}", item.TagNo);
            log.DebugFormat("TagUrlType == {0}", item.TagUrlType);
            log.DebugFormat("IsView == {0}", item.IsView);

            return Request.CreateResponse<HsahTag>(HttpStatusCode.Created, item);
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
    }
}
