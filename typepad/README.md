# Typepad installation instructions

1. In your TypePad dashboard select **Design**.
2. On the left sidebar select **Content**.
3. Under Modules, choose **Embed your own HTML** > **Add this module**.  Note: If you do not have the Content or 'Embed Your Own HTML' option with your design, please see Typepad's more specific [installation instructions](http://help.typepad.com/disqus.html).
4. In the label field type "Disqus".
5. Copy and paste the following code into the HTML field.

	```html
	<script type="text/javascript">
	var disqus_shortname = 'EXAMPLE';
	// DON'T EDIT BELOW THIS LINE
	(function () {
	    var loaded = false;
	    function loadDisqus() {
	        if (loaded) return;
	        loaded = true;
	        var div = document.getElementById('all-comments');
	        div.innerHTML = ''; div.id = 'disqus_thread';
	
	        var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
	        dsq.src = '//' + disqus_shortname + '.disqus.com/embed.js';
	
	        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
	
	    }
	
	    if ( document.getElementById('all-comments') || document.readyState === "complete" ) {
	        return setTimeout( loadDisqus, 1 );
	    }
	
	    if ( document.addEventListener ) {
	        document.addEventListener( "DOMContentLoaded", loadDisqus, false );
	        window.addEventListener( "load", loadDisqus, false );
	    } else if ( document.attachEvent ) {
	        document.attachEvent( "onreadystatechange", loadDisqus );
	        window.attachEvent( "onload", loadDisqus);
	    }
	}());
	</script>
	```

6. Replace `EXAMPLE` with your shortname.
7. On the left sidebar select **Custom CSS** and copy and paste the following code.

	```
	# all-comments { display: none !important; } .comments-open { display: none !important; }
	```

8. Save your changes.

[Continue to the getting started guide](https://help.disqus.com/customer/portal/articles/1264625-getting-started).
