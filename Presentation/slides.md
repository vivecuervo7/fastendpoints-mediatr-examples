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
Hi. I'm Isaac.

And, I happen to be a software developer!

No, I started working here actually, with Telstra Purple a little over five years ago, which is about the extent of my career.

In that time, I've been incredibly fortunate enough to have worked on quite a few projects now, across many different domains, and with more than a just a small handful of different technologies.

I've also had a really fantastic support structure around me, and it's allowed me the freedom to really explore different ways of doing things.

That freedom has led to me constantly being on the lookout for new ways of doing things, _especially_ when it comes to making the development experience better.

After all, I set my sights on a career in software development after falling in love with writing code, and honestly I'm probably _still_ in a bit of a honeymoon phase with it, but one thing I'm really focused on is trying to preserve that feeling for as long as possible.

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

By keeping all of our code closely linked together, it allows us to start simple, declaring a single endpoint and easily extending functionality to those supporting classes as required.

That said, so far all we've really done so far is wrap a few helper methods around Minimal API and moved our application layer into the presentation layer.

Honestly if it stopped here I'd probably consider it not worth the risk of leaning so heavily on yet another library.

There's a few tricks left up FastEndpoints' sleeve that really make it an interesting choice though.
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
disabled: true
---

<h3>Endpoint structure</h3>

<span class="slide-reload-marker" style="display:none">reload-1751934151449</span>
<ReloadCodeButton />

<div class="editor-runner">

<<< ../Example_FastEndpoints/Example_FastEndpoints.Api/Features/Users/Temp/Endpoint.cs csharp {monaco-write}

::div
```js {monaco-run} {autorun:false}
const url = 'http://localhost:5158/users/1';
const response = await fetch(url);
const isJson = response.headers.get("content-type")?.includes("application/json");
const data = isJson ? await response.json() : await response.text();
console.log(`Status: ${response.status}`);
console.log(`Body: ${JSON.stringify(data, null, 2)}`);
```
::
</div>


---
disabled: true
---

<h3>Endpoint structure</h3>

<span class="slide-reload-marker" style="display:none">reload-1751934151449</span>
<ReloadCodeButton />

<div class="editor-runner">

<<< ../Example_FastEndpoints/Example_FastEndpoints.Api/Features/Users/Temp/Models.cs csharp {monaco-write}

::div
```js {monaco-run} {autorun:false}
const url = 'http://localhost:5158/users/1';
const response = await fetch(url);
const isJson = response.headers.get("content-type")?.includes("json");
const data = isJson ? await response.json() : await response.text();
console.log(`Status: ${response.status}`);
console.log(`Body: ${JSON.stringify(data, null, 2)}`);
```
::
</div>
