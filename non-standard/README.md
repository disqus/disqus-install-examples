# Disqus for non-standard layouts

## Before you start
- Make sure you've [registered](https://disqus.com/admin/install/) your site with Disqus. Read the [Quickstart Guide](https://help.disqus.com/customer/portal/articles/466182-quick-start-guide) for more information.
- If you have an existing site on Disqus, you can find your “shortname” in Admin > Settings > [General](https://disqus.com/admin/settings/general/).
- This guide provides basic requirements for loading Disqus, but does not make any recommendations on how your overall site layout should be styled or how to load more content in the case of infinite scroll.

Disqus is designed to load at the bottom of your post content, but it is flexible and can be loaded in a variety of different layouts and with different user interactions. We have provided some common non-standard layouts for Disqus and some best practices for getting started.

### [Infinite scroll](/infinite_scroll_template.html)

- Remove `<div id="disqus_thread"></div>` from the previous article DOM before reloading Disqus in the new article. Disqus should only appear 1 time on the page.
- Use the [`DISQUS.reset()` function](https://help.disqus.com/customer/en/portal/articles/472107-using-disqus-on-ajax-sites) to reload a new Disqus thread after your page's content has updated.
    
### [Load after click](/load_after_click_template.html)

- Use an event handler like `.onclick` to refer to an anonymous function where you can place the Disqus [Universal Code](https://disqus.com/admin/universalcode/).

### [Preload before click](/preload_before_click.html)

- Load the Disqus [Universal Code](https://disqus.com/admin/universalcode/) into a `<div>` that is hidden by default and is unhidden after user interaction like a click.
- Use `display: none` on the parent `<div>` so that Disqus can detect it is hidden and prevent expected results.

### [Sidebar](/sidebar.html)

- Similar to preloading before a click, load the Disqus [Universal Code](https://disqus.com/admin/universalcode/) into a sidebar `<div>` that is hidden by default and is unhidden after user interaction like a click.
- Use `display: none` on the parent `<div>` so that Disqus can detect it is hidden and prevent expected results.

## Site Examples
- [The Atlantic](https://www.theatlantic.com/technology/archive/2017/03/trump-android-tweets/520869/) (Load after click)
- [The AVClub](http://www.avclub.com/article/sam-coffey-and-iron-lungs-channel-clash-talk-2-her-251891) (Infinite scroll)