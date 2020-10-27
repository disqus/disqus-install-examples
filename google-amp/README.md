# Disqus for Accelerated Mobile Pages (AMP)

Disqus for Accelerated Mobile Pages (AMP) is a fast-loading, optimized Disqus experience for [Google AMP](https://www.ampproject.org/) compatible pages. AMP is a way to build web pages for static content that renders quickly, especially on mobile devices. The Disqus Universal Code can be implemented on an AMP compatible page.

## Before you start
- If you haven't done so already, you'll want to familiarize yourself with Google's [What Is AMP?](https://www.ampproject.org/docs/get_started/about-amp.html) and [Create Your First AMP Page](https://www.ampproject.org/docs/get_started/create.html).
- Make sure you've [registered](https://disqus.com/admin/install/) your site with Disqus. Read the [Quickstart Guide](https://help.disqus.com/customer/portal/articles/466182-quick-start-guide) for more information.
- If you have an existing site on Disqus, you can find your “shortname” in Admin > Settings > [General](https://01298301298.disqus.com/admin/settings/general/).
- Make sure you can host the installation code on two _different_ domains.

## How to install

1. Create and host the following Universal Code file on a different domain than where you intend to load Disqus for AMP. This will be the URL that you will provide to the `src` attribute in step 3 below. Make sure to replace the EXAMPLE inside `s.src` with the name of your own forum.

    ```html
    <div id="disqus_thread"></div>
    <script>
    window.addEventListener('message', receiveMessage, false);
    function receiveMessage(event)
    {
        if (event.data) {
            var msg;
            try {
                msg = JSON.parse(event.data);
            } catch (err) {
                // Do nothing
            }
            if (!msg)
                return false;

            if (msg.name === 'resize' || msg.name === 'rendered') {
                window.parent.postMessage({
                  sentinel: 'amp',
                  type: 'embed-size',
                  height: msg.data.height
                }, '*');
            }
        }
    }
    </script>
    <script>
        /**
         *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
         *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables
         */
        var disqus_config = function () {
            this.page.url = window.location;  // Replace PAGE_URL with your page's canonical URL variable
            this.page.identifier = window.location.hash; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
        };
        (function() {  // DON'T EDIT BELOW THIS LINE
            var d = document, s = d.createElement('script');

            s.src = '//EXAMPLE.disqus.com/embed.js';

            s.setAttribute('data-timestamp', +new Date());
            (d.head || d.body).appendChild(s);
        })();
    </script>
    ```

2. Refer to the `amp-iframe` [documentation](https://www.ampproject.org/docs/reference/extended/amp-iframe.html) and add the required `amp-iframe` script to your document's `<head>`. :

    ```html
    <script async custom-element="amp-iframe" src="https://cdn.ampproject.org/v0/amp-iframe-0.1.js"></script>

    ```

3. Place the following `<amp-iframe>` element anywhere within the `<body>` of your AMP page. It will likely make sense to place it at the end of your article content, where ever your audience should engage further after reading.

    ```html
    <amp-iframe width=600 height=140
                layout="responsive"
                sandbox="allow-scripts allow-same-origin allow-modals allow-popups allow-forms"
                resizable
                src="https://example.com/amp#hash"
    >
        <div overflow
             tabindex=0
             role=button
             aria-label="Load more"
             style="display:block;font-size:12px;font-weight:500;font-family:Helvetica Neue, arial, sans-serif;text-align:center;line-height:1.1;padding:12px 16px;border-radius:4px;background:rgba(29,47,58,0.6);color:rgb(255,255,255)"
        >
            Load more
        </div>
    </amp-iframe>
    ```

4. Replace `hash` with a unique identifier that represents the page where you’d like a specific thread to display. If you are loading the `<amp-iframe>` element on multiple pages, generate the `hash` dynamically for each page. The hash you provide will be used in the `identifier` variable in step 1. Learn more about [identifiers](https://help.disqus.com/customer/en/portal/articles/472098-javascript-configuration-variables#thispageidentifier).

5. Add the new domain as a Trusted Domain in your Admin > Settings > [Advanced](https://disqus.com/admin/settings/advanced/).

[Continue to the getting started guide](https://help.disqus.com/customer/portal/articles/1264625-getting-started).

## How to add comment counts (optional)

1. Place the following scripts to the `<head>` of your AMP page. This will allow you to use [`<amp-list>` elements](https://amp.dev/documentation/components/amp-list/) to fetch comment counts and [`amp-mustache` templates](https://amp.dev/documentation/examples/components/amp-mustache/) to dynamically add the comment counts to your site.
    ```html
    <script async custom-element="amp-list" src="https://cdn.ampproject.org/v0/amp-list-0.1.js"></script>
    <script async custom-template="amp-mustache" src="https://cdn.ampproject.org/v0/amp-mustache-0.2.js"></script>
    ```
    
2. Add an `<amp-list>` to the `<body>` of your AMP page containing a call to EXAMPLE.disqus.com/count-data.json and the template that will be used to display the comment counts. You can follow this example:

```
<amp-list
    width="auto"
    height="20"
    layout="fixed-height"
    src="//EXAMPLE.disqus.com/count-data.json?url=YOUR_URL"
>
    <template type="amp-mustache">
        <span>
            <a href="{{url}}">{{comments}} comments</a>
        </span>
    </template>
</amp-list>
```

Make sure to replace `EXAMPLE` with your forum shortname and `YOUR_URL` with the url for the thread that you'd like to get comment count data for. A thread's `identifier` can also be passed as a parameter to `count-data.json`. Multiple urls and identifiers can be passed in a single call to `count-data.json`. For example, using `//EXAMPLE.disqus.com/count-data.json?url=FIRST_URL&url=SECOND_URL&identifier=THIRD_IDENTIFIER&identifier=FOURTH_IDENTIFIER` in the `src` of the `<amp-list>` element will fetch comment counts for four threads. Note that passing both the `url` and `identifier` for a single thread will cause the thread to be returned twice.  

The endpoint will return a JSON object containing a key called `items`, which contains the requested thread objects. Each thread object will contain `url`, `identifier`, and `comments` (the number of comments on the thread). The contents of the template can be customized as needed.

## How to add standalone recommendations (optional)

Adding standalone recommendations is very similar to adding a comment thread to an AMP page. Recommendations can be added to any page, with or without comments on the same page.

1. Create and host the following Universal Code file on a different domain than where you intend to load Disqus Recommendations for AMP. This will be the URL that you will provide to the `src` attribute in step 3 below. Make sure to replace the EXAMPLE inside `s.src` with the name of your own forum.

    ```html
    <div id="disqus_recommendations"></div>
    <script>
    window.addEventListener('message', receiveMessage, false);
    function receiveMessage(event)
    {
        if (event.data) {
            var msg;
            try {
                msg = JSON.parse(event.data);
            } catch (err) {
                // Do nothing
            }
            if (!msg)
                return false;
            if (msg.name === 'resize' || msg.name === 'rendered') {
                window.parent.postMessage({
                  sentinel: 'amp',
                  type: 'embed-size',
                  height: msg.data.height
                }, '*');
            }
        }
    }
    </script>
    <script>
        /**
         *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
         *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables
         */
        var disqus_config = function () {
            this.page.url = window.location;
        };
        (function() {  // DON'T EDIT BELOW THIS LINE
            var d = document, s = d.createElement('script');
            s.src = '//EXAMPLE.disqus.com/recommendations.js';
            s.setAttribute('data-timestamp', +new Date());
            (d.head || d.body).appendChild(s);
        })();
    </script>
    ```

2. Skip this step if you already have comments on the same page loading recommendations. Refer to the `amp-iframe` [documentation](https://www.ampproject.org/docs/reference/extended/amp-iframe.html) and add the required `amp-iframe` script to your document's `<head>`. :

    ```html
    <script async custom-element="amp-iframe" src="https://cdn.ampproject.org/v0/amp-iframe-0.1.js"></script>

    ```

3. Place the following `<amp-iframe>` element anywhere within the `<body>` of your AMP page.

    ```html
    <amp-iframe width=600 height=140
                layout="responsive"
                sandbox="allow-scripts allow-same-origin allow-modals allow-popups allow-forms"
                resizable
                src="https://example.com/amp">
      <div overflow tabindex=0 role=button aria-label="Show recommendations">Show recommendations</div>
    </amp-iframe>
    ```

4. Add the new domain as a Trusted Domain in your Admin > Settings > [Advanced](https://disqus.com/admin/settings/advanced/). 

5. Change your recommendations settings to only load in the standalone position in your Admin > Settings > [Recommendations](https://disqus.com/admin/settings/recommendations/).
