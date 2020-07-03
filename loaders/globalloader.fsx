#r "../_lib/Fornax.Core.dll"

type SiteInfo = {
    title: string
    description: string
    ci: bool
}

let loader (projectRoot: string) (siteContent: SiteContents) =
    let isCI = 
        let envCI, success = System.Environment.GetEnvironmentVariable "CI" |> System.Boolean.TryParse
        if success then envCI else false
    siteContent.Add({title = "Sample Fornax blog"; description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"; ci=isCI})

    siteContent
