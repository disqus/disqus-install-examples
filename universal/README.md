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

## How to display comment count

1. Place the following code before your site's closing `</body>` tag:

	```html
	<-- IMPORTANT: Replace EXAMPLE with your forum shortname! --> <script id="dsq-count-scr" src="//EXAMPLE.disqus.com/count.js" async></script>
	```
2. Append `#disqus_thread` to the `href` attribute in your links. This will tell Disqus which links to look up and return the comment count. For example: `<a href="http://example.com/bar.html # disqus_thread">Link</a>`.

## Additional customization

See our [Tightening your Disqus integration](https://help.disqus.com/customer/portal/articles/565624-tightening-your-disqus-integration) documentation.  
