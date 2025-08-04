---
layout: section
---

<div class="text-size-4xl mx-30">
  Can't we just do that ourselves?
</div>

<!-- 
And, it's at this point that it's worth asking a very valid question, which is "can't we just do that ourselves?"

And yeah, it's not too difficult to simply register a bunch of different endpoints in different files.

We've kind of solved that whole problem that I was talking about, _and_ avoided the need to bring in an additional dependency.

Concerns about whether FastEndpoints is going to be the next MediatR in going commercial aside, I think it still offers enough that it's absolutely worth using over barebones Minimal API, or using controllers.
 -->

---

<h1>FastEndpoints</h1>
<h2>More bang for your buck</h2>

<ul class="content">
  <li>Encourages the use of vertical slices — no more “endpoint here” and “handler there”</li>
  <v-clicks>
    <li>Introduces strong conventions, lowering the surface area for disagreement</li>
    <li>Reduced boilerplate — less code to read, write and maintain</li>
    <li>Facilitates many of the common features that typically need to be tacked onto every project, such as validation, mapping and error handling</li>
  </v-clicks>
</ul>

<!-- 
At a very high level, and starting from the least specific to FastEndpoints, but still a noteworthy benefit, there is a very strong encouragement of the use of vertical slices.

Personally, this one ticks off a bit of an annoyance of mine with regards to the typical architecture I've encountered, where to implement a basic feature or even slightly modify some code requires opening heaps of files from across multiple projects. [click]

FastEndpoints introduces opinionated ways of doing things.

While there are options on how exactly to hold parts of it, for the most part it feels like there's a "right" way to do things. [click]

Couple that with FastEndpoint's concise implementations, and the surface area for disagreements on written code is far lower. [click]

And the thing that we're going to dive into in a bit more detail, is the various features that FastEndpoints offers straight out of the box, that really make working with it quite a pleasurable experience.
 -->
