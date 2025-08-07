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

[click] It also cuts down on the areas of code that we might disagree on.

Considerations around whether we should be returning anything from commands, or how we're communicating failure states back to the API, all become moot.

[click] It's also easy for us to get started with a _very_ basic implementation.

Often I've seen the scaffolding of a backend include an endpoint to prove functionality, and we've already got queries and handlers flying around just to establish a pattern.

That same endpoint in FastEndpoints can be a single file with very little code.

We don't need to go adding commands and handlers, mapping, or exception handling middleware just to get started.

Our codebase grows organically, with any complexity being added as we need it &mdash; not just "in case".

[click] Now, not to be all sunshine and rainbows, FastEndpoints really is best suited to building explicitly web APIs.

If we need to invoke business logic from different interfaces &mdash; Function Apps, background jobs, etc., then we might be better off looking to decouple the application layer.

This can in turn make the endpoint-per-class approach feel a bit cumbersome, with lots of files that mostly just end up having a single method call each.
-->

---
layout: cover
---

<div class="grid grid-cols-[1fr_auto_1fr] items-center w-[55%] space-x-6 mx-auto">
<img src="../images/FE-logo.svg" class="view-transition-fe-logo">
<p class="text-3xl">❤️</p>
<p class="text-2xl font-serif">Web&nbsp;APIs</p>
</div>

<!--
So, there definitely is a clear application for FastEndpoints, and when it's the right fit it can feel _very_ right.

It's very easy to get started and throw together a few endpoints, so there's certainly no harm in spinning up a project and giving it a play!
-->