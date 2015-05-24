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
            <conditions>
              <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            </conditions>
            <match url="^(.+)\.\d+(\.(js|css|png|jpg|gif)$)" />
            <action type="Rewrite" url="{R:1}{R:2}" />
          </rule>
        </rules>
      </rewrite>
    </system.webServer>

