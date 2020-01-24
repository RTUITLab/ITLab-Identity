using System.Collections.Generic;
using ITLab.Identity.Admin.Configuration.Identity;

namespace ITLab.Identity.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






