

//var addHashtag = document.querySelector('.mypost-hashtag');
//addHashtag.addEventListener('click', function (e) {
//    document.getElementById('textEditor').value += "#";
//});
//const commentInput = document.querySelector(".inputComment");
//const commentContainer = document.querySelector(".comment-sec");
//var commentLayout = 
//    `<div class="row "><img class="post-profile-img mt-4 " src="unnamed.jpg"><div class="col-sm-10 mt-3 mr-0"><div class="card comment"><div class="card-body"> <div class="comment--header"><a class="card-title comment--auther " href="#">Special title treatment </a><div class="options-sec"><p class="text-right font-weight-light comment--operation"> 13h <i class="fas fa-ellipsis-h option-click " id="comment-option-click"></i> </p><div class="card comment-options" id="comment-options-list" style="width: 15rem;"><div class="card-body pt-2 pb-1 "><p class="card-text "> <i class="fas fa-link"></i> Copy Link to Comment</p><p class="card-text"> <i class="far fa-flag"></i> Report</p><p class="card-text"> <i class="fas fa-pen"></i> Edit</p><p class="card-text" data-toggle="modal" data-target="#exampleModalScrollable"> <i class="fas fa-trash"></i> Delete</p></div></div></div></div><p class="font-weight-light comment--auth-job">Light weight text.</p><p class="card-text comment--text"></p></div></div></div></div> <!--End Comment--><!-- React--><div class="row "><div class="col-sm-6 ml-5 "><div class="card comment-bar "><div class="card-body pt-1"><i class="far fa-thumbs-up pr-2 comment-like"></i> <span class="line"><span class="font-weight-light likes-no">.1 Like</span> </span><i class="far fa-comment-alt pl-3"></i></div></div></div></div><!--End React-->`;

//var onAddBtn = function (e) {
//    var commentValue = commentInput.value;
//    if (commentContainer.childElementCount === 0) {
//        commentContainer.inner
//    }

//};

//commentInput.addEventListener('keypress', function (event) {
//    if (event.keyCode === 13 || event.which === 13) {
//        onAddBtn(event);
//    }
//});

//document.querySelector('.comment-like').addEventListener('click', function () {
//    document.querySelector('.comment-like').classList.toggle('text-primary');
//    document.querySelector('.likes-no').classList.toggle('pr-2');
//    document.querySelector('.likes-no').classList.toggle('d-inline');

//});

// dropdownList for post options
//document.getElementById('post-option-click').addEventListener('click', function () {
//    document.getElementById('post-options-list').classList.toggle('d-block');
//});

// dropdownList for comment options
document.getElementById('comment-option-click').addEventListener('click', function () {
    document.getElementById('comment-options-list').classList.toggle('d-block');
});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})


////////////////////////////SELECTORS//////////////////////////////////

// trigger for nextbutton to dismiss picture modal and show post modal with the same photos
const nextButton = document.getElementById("next-button");

//trigger for picture modal
const selectPhoto = document.getElementById("edit-post-photo");

// trigger for post modal
const startPost = document.getElementById("startPost");

// post modal container
const postModal = document.getElementById("post");
// picture modal container
const pictureModal = document.getElementById("picture");

// container to put images in picture modal
const editPostPhotoContainer = document.getElementById("edit-post-photo-container");
// container to put images in post modal
const submitPostPhotoContainer = document.getElementById("submit-post-photo-container");

// variable for postbodytext 
const postBodyText = document.getElementById('textEditor');

postBodyText.addEventListener('input', function (e) {
    let postBodyTextValue = postBodyText.value;

    if (postBodyTextValue == null || postBodyTextValue.trim() == "") {
        validatePostButton(false);

    }
    else {
        validatePostButton(true);
    }
});

// add event on picture modal trigger to rest the container of images in picture modal
selectPhoto.addEventListener("click", function () {
    editPostPhotoContainer.innerHTML = "";
})

// add event on post modal trigger to rest the container of images in post modal
startPost.addEventListener("click", function () {
    submitPostPhotoContainer.innerHTML = "";
    validatePostButton(false);
})

selectPhoto.addEventListener("change", handleFiles, false);

// function to handle uploaded images and fire trigger for nextbutton and check for next button availibilty
function handleFiles() {
    const fileList = this.files; /* work with the file list */
    // hide the postModal behind pictureModal
    // chech next button 
    if (fileList != null) {
        // adjust html elements for photos

        displayFileListInContainer(fileList, editPostPhotoContainer);

        nextButton.addEventListener("click", callPostModal(fileList, submitPostPhotoContainer));
        console.log(fileList);
        validatePostButton(true);
    } else {
        validatePostButton(false)
    }
}


function callPostModal(fileList, container) {
    displayFileListInContainer(fileList, container);


}

function displayFileListInContainer(fileList, container) {
    container.innerHTML = "";
    for (var i = 0; i < fileList.length; i++) {
        const photoElement = document.createElement("div");
        container.appendChild(photoElement);

        const img = document.createElement("img");
        img.src = URL.createObjectURL(fileList[i]);
        img.className = "uploaded-image";
        img.onload = function () {
            URL.revokeObjectURL(this.src);
        }
        photoElement.appendChild(img);
    }
}


function validatePostButton(flag) {
    if (flag) {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishDisable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishEnable');
    }
    else
    {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishEnable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishDisable');
    }

}


//called on ajax success of creating new post
function onCreatingPost()
{
    $("#post").modal("hide");
    document.getElementById("form0").reset();
}

///////////////EVENT DELEGATION//////

//for post options
document.getElementById('posts-container').addEventListener('click', handleOptions)
document.querySelector('.comment-sec').addEventListener('click', handleOptions)

//handle options dropdown for posts /comments
function handleOptions()
{
    console.log(event.target.parentNode.nextElementSibling);
    event.target.parentNode.nextElementSibling.classList.toggle('d-block');
}