using System;
using WebApplication1.Properties;
using Microsoft.NAV;

public static class ODataWebService
{

    private static string vCompanyID = "ee7bd08b-fb52-ea11-bba2-00155df3a615";
    public static string BuildODataUrl( bool pByCompany = true)
    {
        string iUrl = "";

        if (pByCompany)
        {
            if (string.IsNullOrEmpty(vCompanyID))
            {
                company iCompany = null;
              //  iCompany = GetEntityCollection<Bcompanies>(string.Format("$filter=name eq '{0}'", Settings.Default.CompanyName), false).value.FirstOrDefault();

                if (iCompany != null)
                    vCompanyID = iCompany.id.ToString();
            }

            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + Settings.Default.TenantId + "/" + Settings.Default.Environment + "/" + Settings.Default.apiVersion + string.Format("/companies({0})/", vCompanyID);
        }
        else
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + Settings.Default.TenantId + "/" + Settings.Default.Environment + "/" + Settings.Default.apiVersion;

        return iUrl;
    }

   

    public static System.Net.ICredentials CreateCredentials(string pWSUrl)
    {
        System.Net.NetworkCredential iCredential = new System.Net.NetworkCredential(Settings.Default.Username, Settings.Default.Password);
        System.Net.ICredentials iCredentials = iCredential.GetCredential(new Uri(pWSUrl), "Basic");

        return iCredentials;
    }
}
