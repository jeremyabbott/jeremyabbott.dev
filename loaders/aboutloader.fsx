#r "../_lib/Fornax.Core.dll"
#r "../_lib/Markdig.dll"

open Markdig

type About = {
    File: string
    Content: string
}

let aboutFileName = "about.md"

let markdownPipeline =
    MarkdownPipelineBuilder()
        .UsePipeTables()
        .UseGridTables()
        .Build()

let loader (projectRoot: string) (siteContents: SiteContents) =
    let aboutFilePath = System.IO.Path.Combine(projectRoot, aboutFileName)
    let content = 
        let text = System.IO.File.ReadAllText aboutFilePath
        Markdown.ToHtml(text, markdownPipeline)
    let about = { File = aboutFilePath; Content = content }
    siteContents.Add(about)
    siteContents