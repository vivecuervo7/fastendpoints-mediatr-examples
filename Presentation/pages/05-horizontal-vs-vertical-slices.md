<h1>FastEndpoints</h1>
<h2>Horizontal vs. vertical slices</h2>

<div class="files-columns mt-8">
  <div v-click="0">
    <ul class="box files">
      <li>
        <span><ProjectIcon />Api</span>
        <ul>
          <li>
            <span><FolderIcon />Dtos</span>
            <ul>
              <li><span><CsharpIcon />GetUserRequest.cs</span></li>
              <li><span><CsharpIcon />GetUserResponse.cs</span></li>
            </ul>
          </li>
          <li>
            <span><FolderIcon />Controllers</span>
            <ul>
              <li><span><CsharpIcon />UsersController.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Application</span>
        <ul>
          <li>
            <span><FolderIcon />Queries</span>
            <ul>
              <li><span><CsharpIcon />GetUserQuery.cs</span></li>
              <li><span><CsharpIcon />GetUserQueryHandler.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Domain</span>
        <ul>
          <li>
            <span><FolderIcon />Entities</span>
            <ul>
              <li><span><CsharpIcon />User.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Infrastructure</span>
        <ul>
          <li><span><CsharpIcon />AppDbContext.cs</span></li>
        </ul>  
      </li>
    </ul>
    <ul class="font-serif text-gray-400 !list-none">
      <li class="!ml-1">Hard to find or review code</li>
      <li class="!ml-1">Too many places for code</li>
      <li class="!ml-1">Domain logic present in application layer</li>
      <li class="!ml-1">Handlers calling each other</li>
    </ul>
  </div>

  <div v-click="1" class="relative">
    <div class="bracket">
      <div></div>
      <img src="../images/FE-icon.svg" class="icon">
      <div></div>
    </div>
    <ul class="box files">
      <li class="view-transition-files">
        <span><ProjectIcon />Api</span>
        <ul>
          <li>
            <span><FolderIcon />Features</span>
            <ul>
              <li>
                <span><FolderIcon />Users</span>
                <ul>
                  <li>
                    <span><FolderIcon />GetUser</span>
                    <ul>
                      <li><span><CsharpIcon />Data.cs</span></li>
                      <li><span><CsharpIcon />Endpoint.cs</span></li>
                      <li><span><CsharpIcon />Mapper.cs</span></li>
                      <li><span><CsharpIcon />Models.cs</span></li>
                    </ul>
                  </li>
                </ul>
              </li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Domain</span>
        <ul>
          <li>
            <span><FolderIcon />Entities</span>
            <ul>
              <li><span><CsharpIcon />User.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Infrastructure</span>
        <ul>
          <li><span><CsharpIcon />AppDbContext.cs</span></li>
        </ul>  
      </li>
    </ul>
    <ul class="font-serif text-gray-400 !list-none">
      <li class="!ml-1">Easy to find related code</li>
      <li class="!ml-1">Reviewing changes doesn't require bouncing around</li>
      <li class="!ml-1">Clearer responsibilities between classes</li>
    </ul>
  </div>
</div>

<!-- 
First off, we'll have a quick look at the basic structure of an endpoint.

On the left here we've got a pretty basic view of the sort of architecture that I frequently encounter. All of these files would typically be required to implement a single, basic feature &mdash; in this case, a simple request to get a user.

We've got our Api project, and our DTOs, controllers all grouped together.

Our application layer has our query and handler, and we've got our all-too expected user entity and `DbContext`.

Naturally, as a project grows, it becomes quite hard to navigate and find specific handlers or entities etc.

As our business logic increases in complexity, we risk ending up with handlers calling other handlers with no sense of visible hierarchy, and it can quickly turn into a spiderweb that's difficult to understand.

[click]

The vertical slice architecture encouraged by FastEndpoints comprises of a single endpoint, or feature, nested under appropriately-named folders.

Now, I fully understand that this may not be everyone's cup of tea, and we're free to name our classes however we please, but the majority of the examples &mdash; not just in this presentation, but out in the wild &mdash; will follow this naming pattern or similar.

But thanks to namespaces, if we so wish to adopt the convention we can have a series of files that very explicitly reflects what they do, consistently, across every endpoint.
 -->