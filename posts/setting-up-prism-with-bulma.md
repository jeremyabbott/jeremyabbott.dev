---
layout: post
title: Setting up Prism with Bulma
author: Jeremy Abbott
published: 2020-07-02
---

# Setting up Prism with Bulma

When you create a new site with Fornax via `fornax new`, or `dotnet fornax new` in my case, you get a new static site that uses Bulma. This is fine until you add in Prism.

![F# code snippet with numbers formatted incorrectly](/images/prism_bulma_name_conflict.png)

As it turns out, both Bulma's CSS and Prism's CSS have a class called `number` and the Bulma class is applying some behavior that we really don't want. 

## The Solution

Googling "Bulma and Prism" I found that [someone had opened a Bulma issue for this exact thing](https://github.com/jgthms/bulma/issues/1708). After reading through the comments (Scary. I know.) it turns out that Prism has a plugin for addressing problems like this. The [Custom Class plugin](https://prismjs.com/plugins/custom-class/) allows you to rename any Prism class. After adding the plugin to my `prism.js` file, all I needed to do was map the class name `number` to something else:

```fsharp
script [Src "/js/prism.js"; Type "text/javascript"] [] // this was already in layout.fsx
// Uses the custom class plugin to change the class "number" to "pr-number"
script [Type "text/javascript"] [string "Prism.plugins.customClass.map({number: 'pr-number'})"]
```

And now as you can see (I hope 😉), numbers look like they're supposed to:

```fsharp
type Pokemon = { Number: int; Name: string }
let pikachu = { Number = 25; Name = "Pikachu" }
```