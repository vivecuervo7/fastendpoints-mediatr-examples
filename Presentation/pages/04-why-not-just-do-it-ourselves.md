---
layout: section
---

<div class="text-size-4xl mx-30">
  Can't we just do that ourselves?
</div>

<!-- 
And, it's at this point that it's worth asking a very valid question, which is "can't we just do that ourselves?"

And sure, it's not too difficult to simply register a bunch of different endpoints in different files.

We've kind of solved that whole problem that I was talking about, _and_ avoided the need to bring in an additional dependency, right?

I can certainly accept that as an argument. I can't guarantee that FastEndpoints won't be the next FluentAssertions or MediatR. Even if it's printed on a shirt.

That particular argument aside, I believe that FastEndpoints offers enough additional features and benefits that it is absolutely worth considering using.
 -->

---

<h1>FastEndpoints</h1>
<h2>More bang for your buck</h2>

<ul class="content">
  <li>Encourages the use of vertical slices — no more “endpoint here” and “handler there”</li>
  <li>Introduces strong conventions, lowering the surface area for disagreement</li>
  <li>Reduced boilerplate — less code to read, write and maintain</li>
  <li>Facilitates many of the common features that typically need to be tacked onto every project, such as validation, mapping and error handling</li>
</ul>

<!-- 
At a very high level, and starting from the less specific to FastEndpoints but still a noteworthy benefit that it brings, there is a very strong encouragement of the use of vertical slices.

Personally, this one ticks off a bit of an annoyance of mine with regards to the typical architecture I've encountered, where to implement a basic feature or even slightly modify some code requires opening a slew of files from across multiple projects.

FastEndpoints introduces opinionated ways of doing things. While there are options on how exactly to hold parts of it, for the most part it feels like there is a "right" way to do things.

This is something I've slowly come around to.

I've often disliked tools or frameworks that are opinionated in ways that I find disagreeable, but I've never been able to find an argument against having them in a codebase.

Couple that with FastEndpoint's concise implementation, and the surface area for disagreements on written code is far lower &mdash; which is one of the things I often strive for in any codebase.

And the thing that we're going to dive into in a bit more detail, is the various features that FastEndpoints offers straight out of the box.
 -->
