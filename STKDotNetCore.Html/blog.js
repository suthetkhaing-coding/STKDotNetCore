const tblBlog = "blogs";
//readBlog();
// createBlog();
//updateBlog("9242eee4-1045-43c6-abaa-835894b6d9c5", "afddf update", "dfhidshf", "fijeihfoif");
//deleteBlog("9242eee4-1045-43c6-abaa-835894b6d9c5");

function readBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if(blogs !== null){
    lst = JSON.parse(blogs);
    }

    const requestModel = {
        id : uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content"
    };

    lst.push(requestModel);

    var jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    //localStorage.setItem("blogs", jsonBlog);
}

function updateBlog(id, title, author, content){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
   
    let lst = [];
    if(blogs !== null){
    lst = JSON.parse(blogs);
    }

    var items = lst.filter( x=> x.id === id);
    console.log(items);

    console.log(items.lenth);

    if(items.lenth == 0){
        console.log("No data found.");
        eturn;
    }

    let item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    var jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function deleteBlog(id){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
   
    let lst = [];
    if(blogs !== null){
    lst = JSON.parse(blogs);
    }

    var items = lst.filter( x=> x.id === id);
    if(items.lenth == 0){
        console.log("No data found.");
        eturn;
    }

    lst = lst.filter( x=> x.id !== id);
    
    var jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }