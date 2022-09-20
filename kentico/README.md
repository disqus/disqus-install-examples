# Xperience by Kentico installation instructions

1. Install the latest [Kentico.Xperience.Disqus.Widget](https://www.nuget.org/packages/Kentico.Xperience.Disqus.Widget#versions-body-tab) NuGet package in your Xperience by Kentico project.
1. Open the [Disqus Admin](https://disqus.com/admin/) website.
    1. Select the "I want to install Disqus on my site" option if you haven't done so before.
    1. Create a new site (or select an existing one) and note the __Shortname__ from __Settings__ -> __General__ tab.
1. In your project's `appsettings.json`, add the following setting:

```json
"xperience.disqus":  {
    "siteShortname": "my-awesome-site"
}
```

## Adding Disqus widget to your pages

The __Disqus comments__ widget can be added as a standard Page Builder widget to any page with the Page Builder where editable area restrictions and widget zone restrictions were adjusted accordingly.

Alternatively, the widget can be added directly to your views as a [standalone widget](https://docs.xperience.io/x/_AWiCQ):

```cs
@using Kentico.Xperience.Disqus

<standalone-widget widget-type-identifier="@DisqusComponent.IDENTIFIER" widget-properties="new DisqusComponentProperties()" />
```

There are 3 optional properties that you can configure:

- __Title__ - A custom title for the created Disqus thread. If not set, the `DocumentName` or HTML `title` will be used.
- __PageIdentifier__ - The [Disqus identifier](https://help.disqus.com/en/articles/1717082-what-is-a-disqus-identifier) of the created thread. If not set, the `DocumentGUID` is used.
- __CssClass__ - One or more classes to add to the `<div>` element that surrounds the Disqus comments.

The widget can be placed on _any_ view in your .NET Core project. However, if it is placed on a view without representation in the Xperience content tree, the __PageIdentifier__ property must be specified.

> :warning: Do not add more than one instance of the Discus widget on a single page as only one instance can be loaded at once.
