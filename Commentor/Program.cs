using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ClientCredential = Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential;

const string applicationId = "ba6bfb38-c501-4707-97ab-4711a3cb33f7";
const string secret = "_lh8Q~BUmfaNAsn71rS3HZX_MJDjfwsUFk3AQaj0";
const string tenantId = "635aa01e-f19d-49ec-8aed-4b2e4312a627";
const string crmUrl = "https://commentor-sandbox.crm4.dynamics.com";
const string authority = $"https://login.microsoftonline.com/{tenantId}";

var thing = new AuthenticationContext(authority, false);
var credentials = new ClientCredential(applicationId, secret);
var token = await thing.AcquireTokenAsync(crmUrl, credentials);



// var app = ConfidentialClientApplicationBuilder
//     .Create(applicationId)
//     .WithClientSecret(secret)
//     .Build();

Console.WriteLine("Snoop");