using IdentityServer4.Models;
using System.Collections.Generic;
using Client = ITLab.Identity.Admin.Configuration.IdentityServer.Client;

namespace ITLab.Identity.Admin.Configuration
{
    public class IdentityServerDataConfiguration
    {
        public Dictionary<string, Client> Clients { get; set; } = new Dictionary<string, Client>();
        public List<IdentityResource> IdentityResources { get; set; } = new List<IdentityResource>();
        public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
    }
}






