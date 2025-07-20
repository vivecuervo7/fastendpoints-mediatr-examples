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
TODO: Introduction
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
src: ./pages/09-dependency-injection.md
---

---
src: ./pages/10-data-access.md
---

---
src: ./pages/11-entity-mapping.md
---

---
layout: section
---

<div class="text-size-7xl mx-30">
  Sweet, what else?
</div>

<!--
So, FastEndpoints gives us a nice, _expressive_ way to write our endpoints, and reduces a fair amount of boilerplate.

By keeping all of our code closely linked together, it allows us to start simple, declaring a single endpoint and easily extending functionality to supporting classes as required.

No more creating single-line queries and their handlers, or implementing a results pattern to convert errors in our application layer into `ProblemDetails`.

That said, so far all we've done really is wrap a few helper methods around Minimal API and moved our application layer code into the presentation layer.

Not really a big deal, and honestly if it stopped here I'd probably consider it not worth the risk of leaning so heavily on another library.

So, onto the really fun bits.
-->

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
