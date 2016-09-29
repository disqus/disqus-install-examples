# Adobe Muse installation instructions

1. Open your website's `.muse` file and select a page where you would like Disqus to load
2. In the menu, go to Object > **Insert HTML...**
3. Copy and paste the [Universal Embed Code](https://help.disqus.com/customer/portal/articles/472097) in the HTML Code widow. 

    Universal Embed Code:

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
4. Be sure to replace `EXAMPLE` above with your Disqus forum [shortname](https://help.disqus.com/customer/portal/articles/466208-what-s-a-shortname-).

5. Click **OK** to save your changes and **Publish** to deploy your updated website.

[Continue to the getting started guide](https://help.disqus.com/customer/portal/articles/1264625-getting-started).
