function showSubArticleTitleEditDialog(currentTitle, categoryId, articleId, subArticleId){
    Metro.dialog.create({
        title: "Update current title",
        content: `<input type=\"text\" data-role=\"input\" value="${currentTitle}" id="subArticleInputVal">`,
        closeButton: true,
        actions: [
            {
                caption: "Update",
                cls: "js-dialog-close success",
                onclick: function(){
                    currentTitle = $("#subArticleInputVal").val();
                    if (currentTitle === "") {
                        alert("Can't be empty!");
                        return showSubArticleTitleEditDialog(currentTitle, categoryId, articleId, subArticleId, currentTitle);
                    }
                    else {
                        updateSubArticle(categoryId, articleId, subArticleId);
                    }
                }
            }
        ]
    });
}

function showSubArticleBodySaveDialog(categoryId, articleId, subArticleId){
    Metro.dialog.create({
        title: "Update current content",
        content: `Are you sure?`,
        closeButton: true,
        actions: [
            {
                caption: "Yes",
                cls: "js-dialog-close success",
                onclick: function(){
                    updateSubArticle(categoryId, articleId, subArticleId)
                }
            },
            {
                caption: "No",
                cls: "js-dialog-close danger",
                onclick: function(){
                    return false;
                }
            }
        ]
    });
}

function CreateSubArticle(categoryId, articleId, body, title) {
    let url = `subArticle/${categoryId}/${articleId}`;

    let data = {
        title: title,
        body: body
    };

    post(url, data).then(res => {
        if (res.status === 200) {
            location.reload();
        }
        else {
            alert(res.status);
        }
    });
}

function updateSubArticle(categoryId, articleId, subArticleId) {
    let url = `subArticle/${categoryId}/${articleId}/${subArticleId}`;
    let title = $("#subArticleInputVal").length ? $("#subArticleInputVal").val() : null;
    let body = document.getElementById("text-editor").innerHTML;
    
    let data = {
        title: title,
        body: body
    };

    put(url, data).then(res => {
        if (res.status === 200) {
            location.reload();
        }
        else {
            alert(res.status);
        }
    });
}

function showSubArticleCreateDialog (categoryId, articleId){
    Metro.dialog.create({
        overlay: "true",
        title: "Create a new chapter",
        content: `<input type=\"text\" data-role=\"input\" placeholder="title" id="subArticleInputVal"> 
                  <hr />
                  <div id="text-editor"></div> 
                  <script> $('#text-editor').trumbowyg();</script>`,
        closeButton: true,
        actions: [
            {
                caption: "Create",
                cls: "js-dialog-close success",
                onclick: function(){
                    let subArticle = document.getElementById("text-editor").innerHTML;
                    let title = $("#subArticleInputVal").val();
                    if (subArticle === "")
                    {
                        alert("Text can't be empty!");
                        return false;
                    }

                    if (title === "")
                    {
                        alert("Title can't be empty!");
                        return false;
                    }
                    
                    CreateSubArticle(categoryId, articleId, subArticle, title);
                }
            }
        ]
    });
}

function showSubArticleDeleteDialog(categoryId, articleId, subArticleId, currentTitle){
    Metro.dialog.create({
        title: "Delete current chapter",
        content: `Do you really want to delete "${currentTitle}" chapter?`,
        closeButton: true,
        actions: [
            {
                caption: "Yes",
                cls: "js-dialog-close success",
                onclick: function(){
                    deleteSubArticle(categoryId, articleId, subArticleId)
                }
            },
            {
                caption: "No",
                cls: "js-dialog-close danger",
                onclick: function(){
                    return false;
                }
            }
        ]
    });
}

function deleteSubArticle (categoryId, articleId, subArticleId) {
    let url = `subArticle/${categoryId}/${articleId}/${subArticleId}`;
    window.delete(url).then(res => {
        if (res.status === 200) {
            window.location =`admin?currentCategoryId=${categoryId}&currentArticleId=${articleId}`;
        }
        else {
            alert(res.status);
        }
    });
}
