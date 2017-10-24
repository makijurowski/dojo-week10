function BST() {
  var root = this.root;

  this.NewNode = function NewNode(val) {
    this.val = val;
    this.left = null;
    this.right = null;
  };

  this.addNode = function addNode(val) {
    var node = new this.NewNode(val);
    var currentNode = root;
    if (!root) {
      root = node;
      return;
    }
    while (currentNode) {
      if (node.val < currentNode.val) {
        if (!currentNode.left) {
          currentNode.left = node;
          break;
        } else {
          currentNode = currentNode.left;
        }
      } else {
        if (!currentNode.right) {
          currentNode.right = node;
          break;
        } else {
          currentNode = currentNode.right;
        }
      }
    }
    return;
  };
}

var newTree = new BST();
newTree.addNode(5);
newTree.addNode(10);
newTree.addNode(3);
newTree.addNode(20);
newTree.addNode(2);
