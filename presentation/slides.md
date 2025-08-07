---
theme: default
title: FastEndpoints
info: Overview of FastEndpoints features
transition: view-transition
mdc: true
addons:
  - fancy-arrow
fonts:
  serif: Shantell Sans
---

<img src="./images/FE-logo.svg" class="mr-80">
<div class="absolute left-3.5rem bottom-2.5rem">
  Isaac&nbsp;Dedini
</div>

<!--
I started my career working here with Telstra Purple, a little over five years ago now.

And in that time, I've had the incredible fortune to have worked on quite a number of projects, across many different domains, and with more than a just a small handful of different technologies.

One of the recurring technologies I use, is .NET.

Very infrequently have I worked on a project that doesn't use it in some capacity, and more often than not, there's an API component to whatever we're building.

_[[pause]]_

Every one of those projects I've worked on has loosely followed the same structure.

And every time, it's effective.

It works, we're all familiar with it, and it gets the job done.

_[[pause]]_

But I don't _love_ it.

And I say this as someone who still does love writing code.

Call it a prolonged honeymoon phase, or outright delusion if you will.

But I _do_ enjoy writing code, and it bothers me when things feel just that little bit off.

FastEndpoints is a library for .NET that I stumbled across recently, and when it comes to building an API, it rekindled some of that dwindling love that I had for the practice.

Where I realized I was starting to groan a little internally whenever the usual explosion of files and folders appeared, FastEndpoints instead had me picking up the laptop again early on a Saturday morning.

My cricket team wasn't too happy when I turned up late for a game, but there it was.

I was enjoying it again.

And I wanted to share that with you today.
-->

---
src: ./pages/01-introduction.md
---

---
src: ./pages/02-architectural-problems.md
---

---
src: ./pages/03-how-does-fastendpoints-help.md
---

---
src: ./pages/04-why-not-just-do-it-ourselves.md
---

---
src: ./pages/05-horizontal-vs-vertical-slices.md
---

---
src: ./pages/06-basic-endpoint-structure.md
---

---
src: ./pages/07-model-binding.md
---

---
src: ./pages/08-validation.md
---

---
src: ./pages/11-entity-mapping.md
---

---
layout: section
---

<div class="text-size-4xl mx-30">
  So... Minimal API with less code?
</div>

<!--
So, we've got a nice, _expressive_ way to write our endpoints, and it cuts down on a fair bit of boilerplate.

By keeping all of our code closely grouped together, it allows us to start simple.

We can declare a single endpoint and easily extend functionality to those supporting classes as required.

That said, so far all we've really done is wrap a few helper methods around Minimal API and moved our application layer into the presentation layer.

And honestly, if it stopped here I'd probably consider it not worth the risk of leaning so heavily on yet another library.

There's still a few tricks left up FastEndpoints' sleeve though, that really make it an interesting choice.
-->

---
src: ./pages/12-pre-post-processors.md
---

---
src: ./pages/13-events.md
---

---
src: ./pages/14-commands.md
---

---
src: ./pages/15-job-queues.md
---

---
src: ./pages/16-remote-command-bus.md
---

---
src: ./pages/17-remote-event-queues.md
---

---
src: ./pages/18-server-sent-events.md
---

---
src: ./pages/19-integration-testing.md
---

---
src: ./pages/20-conveniences.md
---

---
src: ./pages/21-summary.md
---

---
layout: cover
---

<img src="./images/FE-logo.svg" class="ml-83 mr-70 mt-8 view-transition-fe-logo">
<div class="flex justify-center font-extralight text-slate-500 mt-4">
  Isaac&nbsp;Dedini
</div>

<!--
Thanks!

Any questions?
-->
