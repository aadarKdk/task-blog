// ---------------- AUTH ----------------
async function registerUser() {
    const res = await register(username.value, password.value);
    alert("Registered");
}

async function loginUser() {
    const res = await login(username.value, password.value);

    if (res.token) {
        setToken(res.token);
        alert("Login success");
    } else {
        alert("Login failed");
    }
}

function logoutUser() {
    clearToken();
    alert("Logged out");
}

// ---------------- TASKS ----------------
async function loadTasksUI() {
    const tasks = await getTasks();

    const div = document.getElementById("tasks");
    div.innerHTML = "";

    tasks.forEach(t => {
        div.innerHTML += `
        <div class="card">
            <b>${t.title}</b>
            <p>${t.description}</p>

            <button onclick="editTaskUI('${t.id}', '${t.title}', '${t.description}')">Edit</button>
            <button onclick="deleteTaskUI('${t.id}')">Delete</button>
        </div>`;
    });
}

async function createTaskUI() {
    await createTask({
        title: taskTitle.value,
        description: taskDesc.value,
        status: 0
    });

    loadTasksUI();
}

async function editTaskUI(id, title, desc) {
    const newTitle = prompt("Title", title);
    const newDesc = prompt("Description", desc);

    if (!newTitle || !newDesc) return;

    await updateTask(id, {
        title: newTitle,
        description: newDesc,
        status: 0
    });

    loadTasksUI();
}

async function deleteTaskUI(id) {
    await deleteTask(id);
    loadTasksUI();
}

// ---------------- POSTS ----------------
async function loadPostsUI() {
    const posts = await getPosts();

    const div = document.getElementById("posts");
    div.innerHTML = "";

    posts.forEach(p => {
        div.innerHTML += `
        <div class="card">
            <b>${p.title}</b>
            <p>${p.content}</p>

            <button onclick="editPostUI('${p.id}', '${p.title}', '${p.content}')">Edit</button>
            <button onclick="deletePostUI('${p.id}')">Delete</button>
        </div>`;
    });
}

async function createPostUI() {
    await createPost({
        title: postTitle.value,
        content: postContent.value,
        isPublished: true
    });

    loadPostsUI();
}

async function editPostUI(id, title, content) {
    const newTitle = prompt("Title", title);
    const newContent = prompt("Content", content);

    if (!newTitle || !newContent) return;

    await updatePost(id, {
        title: newTitle,
        content: newContent,
        isPublished: true
    });

    loadPostsUI();
}

async function deletePostUI(id) {
    await deletePost(id);
    loadPostsUI();
}