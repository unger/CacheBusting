# CacheBusting
Helpers to fingerprint urls to static resources

##Installation

http://nuget.org/packages/CacheBusting/

    Install-Package CacheBusting

##Usage

    <link href="@CacheBusting.FingerPrint.WithFileDate("/css/main.css")" rel="stylesheet"/>

or

    <link href="<%= CacheBusting.FingerPrint.WithFileDate("/css/main.css") %>" rel="stylesheet"/>
  
Will render the following
  
    <link href="/css/main.css?v=150414161025" rel="stylesheet"/>
  
It is also possible to not use the querystring for versioning, then some handler or redirectmodule is needed to resolve the url.

    <link href="@CacheBusting.FingerPrint.WithFileDate("/css/main.css", false)" rel="stylesheet"/>

Will render the following
  
    <link href="/css/main.150414161025.css" rel="stylesheet"/>

##Url rewriting

You can use the IIS Url Rewrite Module, that can be installed with the Web platform Installer. Then configure with this config to make the above urls work. (Example from Html5boilerplate IIS server config, with added file exists check)

    <system.webServer>
      <rewrite>
        <rules>
          <rule name="Cachebusting">
            <match url="^(.+)\.\d+(\.(js|css|png|jpg|gif)$)" />
            <conditions>
              <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            </conditions>
            <action type="Rewrite" url="{R:1}{R:2}" />
          </rule>
        </rules>
      </rewrite>
    </system.webServer>

If you also deliver resources with virtual paths that does not exist on disk you can get trouble with the above rewrite rule, to make it compatible you can change the match regexp to only match exactly 12 numerics.

    <match url="^(.+)\.\d{12}(\.(js|css|png|jpg|gif)$)" />
