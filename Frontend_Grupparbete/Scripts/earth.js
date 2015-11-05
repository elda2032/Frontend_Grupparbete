var container, controls, camera, scene, light, renderer;
var WIDTH = window.innerWidth - 30;
var HEIGHT = window.innerHeight - 30;
var angle = 45, aspect = WIDTH / HEIGHT, near = 0.1, far = 3000;

container = document.getElementById("container");

camera = new THREE.PerspectiveCamera(angle, aspect, near, far);
camera.position.set(0, 0, 0);
scene = new THREE.Scene();
camera.lookAt(scene.position);

renderer = new THREE.WebGLRenderer({ antialiasing: true });
renderer.setSize(WIDTH, HEIGHT);

container.appendChild(renderer.domElement);

controls = new THREE.OrbitControls(camera, renderer.domElement);

function animate() {
    requestAnimationFrame(animate);
    controls.update();
    render();
}
function render() {
    renderer.render(scene, camera);
}

animate();