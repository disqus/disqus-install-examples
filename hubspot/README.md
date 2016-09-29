# Hubspot installation instructions

1. From your Hubspot blog admin click **options**.
2. Under General options uncheck **Allow Comments**.
3. Uncheck **Include Footer** on Listing Pages.
4. Click on **HTML** in the blog footer edit menu and paste the following embed code:

	```html
	<div id="disqus_thread"></div>
	<script>
	    /**
	     *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
	     *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables
	     */
	    var disqus_config = function () {
	        this.page.url = PAGE_URL;  // Replace PAGE_URL with your page's canonical URL variable
	        // this.page.identifier = PAGE_IDENTIFIER; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
	    };
	    (function() {  // REQUIRED CONFIGURATION VARIABLE: EDIT THE SHORTNAME BELOW
	        var d = document, s = d.createElement('script');
	        
	        s.src = '//EXAMPLE.disqus.com/embed.js';  // IMPORTANT: Replace EXAMPLE with your forum shortname!
	        
	        s.setAttribute('data-timestamp', +new Date());
	        (d.head || d.body).appendChild(s);
	    })();
	</script>
	<noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript" rel="nofollow">comments powered by Disqus.</a></noscript>
	```

5. Replace **example** with your [Shortname](https://help.disqus.com/customer/portal/articles/466208-what-s-a-shortname-).

6. Replace the `url` parameter in the embed code with `[ARTICLELINK]`.

7. Click Update.

[Continue to the getting started guide](https://help.disqus.com/customer/portal/articles/1264625-getting-started).
