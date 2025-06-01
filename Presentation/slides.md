---
theme: default
title: FastEndpoints
info: Overview of FastEndpoints features
class: text-center
drawings: # https://sli.dev/features/drawing
  persist: false
transition: view-transition # https://sli.dev/guide/animations.html#slide-transitions
mdc: true # https://sli.dev/features/mdc
addons:
  - fancy-arrow
---

<img src="./images/FE-logo.svg" class="mr-80">
<div class="absolute left-3.5rem bottom-2.5rem">
  Isaac&nbsp;Dedini
</div>

<!--
The last comment block of each slide will be treated as slide notes. It will be visible and editable in Presenter Mode along with the slide. [Read more in the docs](https://sli.dev/guide/syntax.html#notes)
-->

---
layout: statement
---

<div class="text-size-4xl mx-30">
  "FastEndpoints is a developer friendly alternative to Minimal APIs & MVC"
</div>

---
layout: section
---

<div class="text-size-7xl mx-30">
  Why?
</div>

---

<h1>Why?</h1>
<h2>What drove me to FastEndpoints?</h2>

<ul class="content">
  <li>A feeling of over-abstracted code in what were often relatively simple APIs</li>
  <li>Stumbled across FastEndpoints online and started tinkering with it out of curiosity</li>
  <li>FastEndpoints felt easy to use where the typical architecture felt cumbersome</li>
  <li>Commercialisation of MediatR led me to consider FastEndpoints as a genuine alternative</li>
</ul>

<!-- 
Every project I’ve worked on has had roughly the same setup for what is usually a relatively simple API, using MediatR to send and handle commands and requests

Scrolling through YouTube one day, I saw a short video covering a very basic API built with FastEndpoints, and I was intrigued by how clean it looked

I had played with it a little, liked what I had seen, but really it was the recent commercialisation of MediatR which made me sit back and think about whether FastEndpoints might be a genuine alternative the usual project structure
-->

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="370,225,240,240">
  <div class="onion-application onion-circle view-transition-application"></div>
</v-drag>

<v-drag pos="425,280,130,130">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="390,195,200,_">
  <div class="onion-label view-transition-presentation-label">Presentation</div>
</v-drag>

<v-drag pos="390,245,200,_">
  <div class="onion-label view-transition-application-label">Application</div>
</v-drag>

<v-drag pos="390,330,200,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
</v-drag>

<v-drag pos="390,470,200,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
Referring back to that typical architecture diagram, one of the biggest problems in my opinion

Makes the handler an attractive place to just dump logic

We end up with domain logic littered throughout our handlers
-->

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="380,235,220,220">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="390,195,200,_">
  <div class="onion-label view-transition-presentation-label">Presentation</div>
</v-drag>

<v-drag pos="390,340,200,_">
  <div class="onion-label view-transition-application-label">Application</div>
</v-drag>

<v-drag pos="390,310,200,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
  <div class="onion-label view-transition-domain-plus">+</div>
</v-drag>

<v-drag pos="390,470,200,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
…and we end up with this big mess in our domain project, with all the application code lumped in there

FastEndpoints allows us to move that application logic into the presentation layer without overloading an already busy controller
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="410,265,160,160">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="390,195,200,_">
  <div class="onion-label view-transition-presentation-label">Presentation</div>
  <div class="onion-label view-transition-presentation-plus">+</div>
</v-drag>

<v-drag pos="390,225,200,_">
  <div class="onion-label view-transition-application-label">Application</div>
</v-drag>

<v-drag pos="390,330,200,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
</v-drag>

<v-drag pos="390,470,200,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
...making it much easier to maintain that clear boundary of the domain layer
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="120,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="210,265,160,160">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="190,195,200,_">
  <div class="onion-label view-transition-presentation-label" v-mark.orange.box="1">Presentation</div>
  <div class="onion-label view-transition-presentation-plus">+</div>
</v-drag>

<v-drag pos="200,225,180,_">
  <div class="onion-label view-transition-application-label" v-mark.purple.box="3">Application</div>
</v-drag>

<v-drag pos="250,330,80,_">
  <div class="onion-label view-transition-domain-label" data-id="domain">Domain</div>
</v-drag>

<v-drag pos="225,470,130,_">
  <div class="onion-label view-transition-infrastructure-label" data-id="infrastructure">Infrastructure</div>
</v-drag>

<v-drag pos="606,167,239,_">
  <div class="box">
    <div v-mark.orange.box="2">
      <p class="!mt-0">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div v-mark.purple.box="4" data-id="handler">
      <p>Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-click at="5">
  <FancyArrow q1="[data-id=handler]" q2="[data-id=domain]" pos1="left" pos2="right" color="purple" arc="0.06" head-size="20" class="z-100" />
</v-click>

<v-click at="6">
  <FancyArrow q1="[data-id=handler]" q2="[data-id=infrastructure]" pos1="left" pos2="right" color="purple" arc="0.15" head-size="20" class="z-100" />
</v-click>

<!--
…by having only one endpoint per file that also contains the handler code
-->
