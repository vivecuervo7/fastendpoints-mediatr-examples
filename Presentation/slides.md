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
The last comment block of each slide will be treated as slide notes. It will be visible and editable in Presenter Mode along with the slide. [Read more in the docs](https://sli.dev/guide/syntax.html#notes)
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
