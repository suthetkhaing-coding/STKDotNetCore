const tblBlog = "blogs";
let blogId = null;

getBlogTable();

//readBlog();
// createBlog();
//updateBlog("9242eee4-1045-43c6-abaa-835894b6d9c5", "afddf update", "dfhidshf", "fijeihfoif");
//deleteBlog("9242eee4-1045-43c6-abaa-835894b6d9c5");

function readBlog() {
    let lst = getBlogs();
    console.log(lst);
}

function editBlog(id) {
    let lst = getBlogs();

    var items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.lenth);

    if (items.lenth == 0) {
        console.log("No data found.");
        errorMessage("No data found.");
        return;
    }

    //return items[0];

    let item = items[0];

    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
}

function createBlog(title, author, content) {
    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);

    var jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    //localStorage.setItem("blogs", jsonBlog);

    successMessage('Saving Successful.');
    clearControls();
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();

    var items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.lenth);

    if (items.lenth == 0) {
        console.log("No data found.");
        errorMessage("No data found.");
        return;
    }

    let item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    var jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage('Updating Successful.');
    clearControls();
}

function deleteBlog(id) {
    // let result = confirm('Are you sure want to delete?');
    // if (!result) return;

    Notiflix.Confirm.show(
        'Confirm',
        'Are you sure want to delete?',
        'Yes',
        'No',
        function okCb() {
            let lst = getBlogs();

    var items = lst.filter(x => x.id === id);
    if (items.lenth == 0) {
        console.log("No data found.");
        return;
    }

    lst = lst.filter(x => x.id !== id);

    var jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage('Deleting Successful.');
    getBlogTable();
        },
        function cancelCb() {
            return;
        },
        {
            width: '320px',
            borderRadius: '8px',
            // etc...
        },
    );

    
}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    return lst;
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId === null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }

    getBlogTable();
});

function successMessage(message) {
    //alert(message);
    Swal.fire({
        title: "Success!",
        text: message,
        icon: "success"
    });
}

function errorMessage(message) {
    //alert(message);
    Swal.fire({
        title: "Error!",
        text: message,
        icon: "error"
    });
}

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" onclick="editBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>
        `;

        htmlRows += htmlRow;
        $('#tbody').html(htmlRows);
    });
}