# Universal Code installation instructions

1. Place the following code where you'd like Disqus to load:

	```html
	<div id="disqus_thread"></div>
	<script>
	    /**
	     *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
	     *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables
	     */
	    /*
	    var disqus_config = function () {
	        this.page.url = PAGE_URL;  // Replace PAGE_URL with your page's canonical URL variable
	        this.page.identifier = PAGE_IDENTIFIER; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
	    };
	    */
	    (function() {  // REQUIRED CONFIGURATION VARIABLE: EDIT THE SHORTNAME BELOW
	        var d = document, s = d.createElement('script');

	        s.src = '//EXAMPLE.disqus.com/embed.js';  // IMPORTANT: Replace EXAMPLE with your forum shortname!

	        s.setAttribute('data-timestamp', +new Date());
	        (d.head || d.body).appendChild(s);
	    })();
	</script>
	<noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript" rel="nofollow">comments powered by Disqus.</a></noscript>
	```

2. (Recommended) Edit the `RECOMMENDED CONFIGURATION VARIABLES` section using your CMS or platform's dynamic values. See our [documentation](https://help.disqus.com/customer/en/portal/articles/2158629) to learn why defining `identifier` and `url` is important for preventing duplicate threads.

[Continue to the getting started guide](https://help.disqus.com/customer/portal/articles/1264625-getting-started).

## How to display comment count

1. Place the following code before your site's closing `</body>` tag:

	```html
	<-- IMPORTANT: Replace EXAMPLE with your forum shortname! -->
	<script id="dsq-count-scr" src="//EXAMPLE.disqus.com/count.js" async></script>
	```
2. Append `#disqus_thread` to the `href` attribute in your links. This will tell Disqus which links to look up and return the comment count. For example: `<a href="http://example.com/bar.html # disqus_thread">Link</a>`.

## Advanced scenarios

Disqus is designed to load at the bottom of your post content, but it is flexible and can be loaded in a variety of different layouts and with different user interactions.

**NOTE:** Each of these scenarios contains compromises you would have to weigh against their benefits:
- Hiding the comments initially will significantly lower engagement from the community.
- Deferring the loading of Disqus will eliminate the SEO benefits of Disqus.

### [Infinite scroll](infinite_scroll_template.html)

Removes `<div id="disqus_thread"></div>` from the previous article DOM before reloading Disqus in the new article. Disqus is limited to one instance in the entire DOM at a time. If multiple are included, only one will be loaded. Uses the [`DISQUS.reset()` function](https://help.disqus.com/customer/en/portal/articles/472107-using-disqus-on-ajax-sites) to reload a new Disqus thread after your page's content has updated.

### [Load after click](load_after_click_template.html)

Uses an event handler like `.onclick` to refer to an anonymous function where you can place the Disqus [Universal Code](https://disqus.com/admin/universalcode/).

### [Show after click](show_after_click_template.html)

Loads the Disqus [Universal Code](https://disqus.com/admin/universalcode/) into a `<div>` that is hidden by default and is unhidden after user interaction like a click. Uses `display: none` on the parent `<div>` so that Disqus can detect it is hidden and prevent expected results.

### [Sidebar](sidebar_template.html)

Similar to preloading before a click, load the Disqus [Universal Code](https://disqus.com/admin/universalcode/) into a sidebar `<div>` that is hidden by default and is unhidden after user interaction like a click. Uses `display: none` on the parent `<div>` so that Disqus can detect it is hidden and prevent expected results.

### [Lazy load](lazy_load_template.html)

Defers loading Disqus until the user has brought comments into view. This is check is triggered after loading, when the user scrolls, and when the window size changes.

#### Site Examples
- [The A.V. Club](http://www.avclub.com/article/sam-coffey-and-iron-lungs-channel-clash-talk-2-her-251891) (Show after click)
- [Stab Magazine](http://stabmag.com/news/kelly-slaters-tired-of-margaret-rivers-main-break/) (Show after click)
- [Highsnobiety](http://www.highsnobiety.com/2017/04/03/supreme-x-north-face-ss17-drop-paris/) (Load after click)
- [The Atlantic](https://www.theatlantic.com/technology/archive/2017/03/trump-android-tweets/520869/) (Load after click)
- [Make:](http://makezine.com/2016/06/30/these-custom-night-vision-goggles-dont-even-look-homemade/) (Sidebar)

## Additional customization

See our [Tightening your Disqus integration](https://help.disqus.com/customer/portal/articles/565624-tightening-your-disqus-integration) documentation.
