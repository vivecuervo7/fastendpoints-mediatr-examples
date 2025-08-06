<h1>FastEndpoints</h1>
<h2>Summary</h2>

<ul class="content">
  <li>Lightweight, expressive code, easy to find where things are implemented</li>
  <v-clicks>
    <li>No results pattern or exceptions required to go from application layer errors to problem details</li>
    <li>Smallest implementation is very basic &mdash; no need to go adding layers of complexity early on just to establish "the way" forward</li>
    <li>Best suited for small to medium APIs, or potentially even larger projects if we're going to stick to a web interface</li>
  </v-clicks>
</ul>

<!--
So, personally I've found FastEndpoints to really streamline building API endpoints.

Even coming back to some older code, it's very easy to navigate and understand an API's structure.

It does away with the layers of indirection and abstractions that just make us think harder than we need to.

[click] It also cuts down the areas of code that we might disagree on.

Considerations around whether we should be returning anything from commands, or how we're communicating failure states back to the API, all become moot.

[click] It's also easy for us to get started with a _very_ basic implementation.

Often I've seen the scaffolding of a backend include a ping endpoint to prove functionality, and we've already got queries and handlers flying around just to establish a pattern.

That same ping endpoint in FastEndpoints can be a single file with very little code.

We don't need to go adding commands and handlers, mapping, or exception handling middleware just to get started.

[click] Now, not to be all sunshine and rainbows, FastEndpoints really is best suited to building explicitly web APIs.

If we need to invoke business logic from different interfaces &mdash; Function Apps, background jobs, etc., then we might be better off looking to decouple the application layer, which can in turn make the endpoint-per-class approach feel a bit cumbersome.

So there definitely is a clear application for FastEndpoints, and when it's the right fit it can feel very right.

But, it's very easy to get started and throw together a few endpoints, so there's certainly no harm in giving a play!
-->
