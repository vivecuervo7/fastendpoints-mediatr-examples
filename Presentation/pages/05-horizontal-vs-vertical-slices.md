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
    <ul>
      <li>Hard to find or review code</li>
      <li>
        Too many places for code; too many decisions
        <ul>
          <li>Handlers often calling other handlers</li>
          <li>Domain logic present in application layer</li>
        </ul>
      </li>
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
    <ul>
      <li>Easy to find related code</li>
      <li>Reviewing changes doesn't require bouncing around</li>
      <li>Clearer responsibilities between classes</li>
    </ul>
  </div>
</div>
