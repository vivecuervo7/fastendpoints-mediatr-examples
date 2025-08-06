<h1>FastEndpoints</h1>
<h2>Integration Testing</h2>

<ul class="content">
  <li>FastEndpoints also provides a testing library to make testing more convenient</li>
  <v-clicks>
    <li>Comes with a set of extension methods for the <strong>HttpClient</strong>, allowing us to easily send our requests</li>
    <li>Uses endpoints, request and response DTOs directly &mdash; no more specifying route URLs when testing endpoints</li>
    <li>If we've annotated our request DTO's properties with attributes such as <strong>[FromHeader]</strong>, the testing library will construct a <strong>HttpResponseMessage</strong> with the correct headers etc.</li>
  </v-clicks>
</ul>

<!--
The last thing that I'll touch on is the testing library that FastEndpoints provides.

While we certainly don't _need_ to use this library, it does cut down on the tedious nature of constructing requests.

[click] The biggest benefit I've found with this personally, is a focus on "route-less testing".

[click] This allows us to use one of many extension methods provided for the `HttpClient` that accept endpoints, and DTOs as arguments, meaning we don't have to specify the route URL when writing the test.

[click] It uses any annotations on our request DTO to construct a `HttpResponseMessage` with the data in the right place &mdash; such as a property with the `FromHeader` attribute being set as a header in the request.
-->
