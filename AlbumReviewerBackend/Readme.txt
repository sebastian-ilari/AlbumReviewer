Start IIS Express: "C:\Program Files (x86)\IIS Express\iisexpress.exe" /siteid:10
(Source: http://www.iis.net/learn/extensions/using-iis-express/running-iis-express-from-the-command-line)


Mac hostname: SebastiansMac
Mac IP from the VM: 192.168.178.101


To allow the WCF Service to accept requests from other domains I added this on the project's web.config:

<httpProtocol>
  <customHeaders>
    <add name="Access-Control-Allow-Origin" value="*" />
	<add name="Access-Control-Allow-Methods" value="GET, POST, PUT"/>
    <add name="Access-Control-Allow-Headers" value="Content-Type" />
  </customHeaders>
</httpProtocol>

This opens requests from all sources (*)


To force all services to return Json I modified the automaticFormatSelectionEnabled and defaultOutgoingResponseFormat properties 
to look like this:

  <system.serviceModel>
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true"></serviceHostingEnvironment>
    <standardEndpoints>
      <webHttpEndpoint>
        <standardEndpoint name="" helpEnabled="true" automaticFormatSelectionEnabled="false" defaultOutgoingResponseFormat="Json"></standardEndpoint>
      </webHttpEndpoint>
    </standardEndpoints>
  </system.serviceModel>

The same can be achived in the Service Interface by adding this code:

[OperationContract]
[WebInvoke(Method = "GET",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "GetArtistsJson")]
List<Artist> GetArtistsJson();



To allow PUT requests from outside in IISExpres:

http://stackoverflow.com/questions/10906411/asp-net-web-api-put-delete-verbs-not-allowed-iis-8


http://johan.driessen.se/posts/Accessing-an-IIS-Express-site-from-a-remote-computer



Access the WCF Service itself:

http://windows:8080/AlbumReviewer/GetArtists
http://windows:8080/AlbumReviewer/GetAlbumsFromArtist/1


Access the WCF Service contract:

http://windows:2588/PersonService/help
or
http://192.168.178.29:2588/PersonService/help


To call the PUT services from Fiddler:

Add this to the header in the Composer tab:

Content-Length: 0