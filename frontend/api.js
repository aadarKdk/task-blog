const BASE_URL = "http://localhost:5193";

// ---------------- TOKEN ----------------
function setToken(t) {
    localStorage.setItem("token", t);
}

function getToken() {
    return localStorage.getItem("token");
}

function clearToken() {
    localStorage.removeItem("token");
}

// ---------------- AUTH ----------------
async function register(username, password) {
    const res = await fetch(`${BASE_URL}/api/auth/register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });
    return res.json();
}

async function login(username, password) {
    const res = await fetch(`${BASE_URL}/api/auth/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });
    return res.json();
}

// ---------------- TASKS ----------------
async function getTasks() {
    const res = await fetch(`${BASE_URL}/api/tasks`, {
        headers: { Authorization: "Bearer " + getToken() }
    });
    return res.json();
}

async function createTask(task) {
    const res = await fetch(`${BASE_URL}/api/tasks`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + getToken()
        },
        body: JSON.stringify(task)
    });
    return res.json();
}

async function updateTask(id, task) {
    await fetch(`${BASE_URL}/api/tasks/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + getToken()
        },
        body: JSON.stringify(task)
    });
}

async function deleteTask(id) {
    await fetch(`${BASE_URL}/api/tasks/${id}`, {
        method: "DELETE",
        headers: { Authorization: "Bearer " + getToken() }
    });
}

// ---------------- POSTS ----------------
async function getPosts() {
    const res = await fetch(`${BASE_URL}/api/posts`, {
        headers: { Authorization: "Bearer " + getToken() }
    });
    return res.json();
}

async function createPost(post) {
    const res = await fetch(`${BASE_URL}/api/posts`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + getToken()
        },
        body: JSON.stringify(post)
    });
    return res.json();
}

async function updatePost(id, post) {
    await fetch(`${BASE_URL}/api/posts/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + getToken()
        },
        body: JSON.stringify(post)
    });
}

async function deletePost(id) {
    await fetch(`${BASE_URL}/api/posts/${id}`, {
        method: "DELETE",
        headers: { Authorization: "Bearer " + getToken() }
    });
}