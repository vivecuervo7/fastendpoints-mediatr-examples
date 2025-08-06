<h1>FastEndpoints</h1>
<h2>Integration Testing</h2>

<ul class="content">
  <li>FastEndpoints also provides a testing library to make testing more convenient</li>
  <v-clicks>
    <li>Comes with a set of extension methods for the <strong>HttpClient</strong>, allowing us to easily send our requests</li>
    <li>Uses endpoints, request and response DTOs directly &mdash; no more specifying route URLs when testing endpoints</li>
    <li>If we've annotated our request DTO's properties with attributes such as <strong>[FromHeader]</strong>, the testing library will construct a <strong>HttpRequestMessage</strong> with the correct headers etc.</li>
  </v-clicks>
</ul>

<!--
The last thing that I'll touch on is the testing library that FastEndpoints provides.

While we certainly don't _need_ to use this library, it does cut down on the tedious nature of constructing requests.

And with tests often being missed altogether, making it as easy as possible to write them can only be a good thing.

[click] The biggest benefit I've found with this personally, is a focus on "route-less testing".

[click] This allows us to use one of many extension methods provided for the `HttpClient` that accept endpoints, and DTOs as arguments or type parameters, meaning we don't have to specify the route URL at all when writing the tests.

[click] It uses any annotations on our request DTO to construct a `HttpRequestMessage` with the data in the right place &mdash; such as a property with the `FromHeader` attribute being set as a header in the request.

Touching lightly on unit testing, the library also provides us with a factory to create instances of our endpoints if we want to test the handler functionality directly, passing in any mocked dependencies.
-->
