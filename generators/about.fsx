#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"

open Html

  
let generate' (ctx : SiteContents) (_: string) =
  let about = 
    ctx.TryGetValue<Aboutloader.About>()
  let aboutContents =
    about
    |> Option.map (fun a -> a.Content)
    |> Option.defaultValue "about"
  let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
  let desc =
    siteInfo
    |> Option.map (fun si -> si.description)
    |> Option.defaultValue ""


  Layout.layout ctx "About" [
    section [Class "hero is-info is-medium is-bold"] [
      div [Class "hero-body"] [
        div [Class "container has-text-centered"] [
          h1 [Class "title"] [!!desc]
        ]
      ]
    ]
    div [Class "container"] [
      section [Class "articles"] [
        div [Class "column is-8 is-offset-2"] [
            div [Class "card article"] [
                div [Class "card-content"] [
                    div [Class "content article-body"] [
                        !! aboutContents
                    ]
                ]
            ]
        ]
      ]
    ]]

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page
  |> Layout.render ctx