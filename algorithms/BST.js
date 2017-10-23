function BST() {
    this.root = null;

    function NewNode(val) {
        this.value = val;
        this.left = null;
        this.right = null;
    }

    function addNode(val) {
        var node = new NewNode(val);
        var pointer = this.root;
        if (!this.root) {
            this.root = node;
        }
        while (pointer) {
            // Continue hereeeee
        }
    }
}