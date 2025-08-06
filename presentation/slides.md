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
Hi. I'm Isaac, and I'm a software developer!

I started working here actually, with Telstra Purple a little over five years ago.

And in that time, I've had the incredible fortune to have worked on quite a few projects now, across many different domains, and with more than a just a small handful of different technologies.

I've also had a really fantastic support structure around me, and it's allowed me the freedom to really explore different ways of doing things.

That freedom has led to me constantly being on the lookout for new ways of doing things, _especially_ when it comes to making the development experience better.

I set my sights on a career in software development after falling in love with writing code, and honestly I'm probably _still_ in a bit of a honeymoon phase with it, but one thing I'm really focused on is trying to preserve that feeling for as long as possible.

FastEndpoints happens to be one of the things that I stumbled across in recent times, and I wanted to share a bit of an overview of it, and also why I think it's worth actually using.
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

By keeping all of our code closely grouped together, it allows us to start simple, declaring a single endpoint and easily extending functionality to those supporting classes as required.

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
