# Ghost installation instructions

1. Find the **post.hbs** file located in your current theme's directory, for example **yourghostdir/content/themes/casper/**

2. Paste the following code between `{{/post}}` and `</article>` :
    
    ```html
    <div id="disqus_thread"></div>
    <script>
        /**
         *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
         *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables
         */
        var disqus_config = function () {
            // this.page.url = PAGE_URL;  // Replace PAGE_URL with your page's canonical URL variable
            this.page.identifier = '{{post.id}}'; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
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
3. Be sure to replace **EXAMPLE** with your Disqus forum [shortname](https://help.disqus.com/customer/portal/articles/466208-what-s-a-shortname-). Note that `{{post.id}}` is used as the disqus_identifer to avoid any issues caused by post URLs changing. See more on [javascript configuration variables](https://help.disqus.com/customer/portal/articles/472098-javascript-configuration-variables).

4. Restart Ghost (unless you are using [Forever](http://support.ghost.org/deploying-ghost/)).

## To install comment counts

1. Edit `default.hbs` and paste the following code just before the `</body>` closing tag:

    ```html
    <script type="text/javascript">
    /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
    var disqus_shortname = **'example'**; // required: replace example with your forum shortname

    /* * * DON'T EDIT BELOW THIS LINE * * */
    (function () {
    var s = document.createElement('script'); s.async = true;
    s.type = 'text/javascript';
    s.src = 'http://' + disqus_shortname + '.disqus.com/count.js';
    (document.getElementsByTagName('HEAD')[0] || document.getElementsByTagName('BODY')[0]).appendChild(s);
    }());
    </script>
    ```

2. Replace `example` with your Disqus forum [shortname](https://help.disqus.com/customer/portal/articles/466208-what-s-a-shortname-).
edit **index.hbs** and find the `post-meta` span and and change it to match the following code:
    
    ```html
    <span class="post-meta">
        <time datetime="{{date format='YYYY-MM--DD'}}">{{date format="DD MMM YYYY"}}</time> 
        {{#if tags}}on {{tags}}{{/if}} 
        <a href="{{url}}#disqus_thread">Comments</a>
    </span>
    ```
Note: the span above is from the default Ghost theme, each theme may be a slightly different. The comment count script looks for `{{url}}#disqus_thread` and replaces with the count link text

For more information, see [Adding comment count links to your home page](https://help.disqus.com/customer/portal/articles/565624-adding-comment-count-links-to-your-home-page).

[Continue to the getting started guide](https://help.disqus.com/customer/portal/articles/1264625-getting-started).
