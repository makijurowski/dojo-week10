function BST() {
  var root = this.root;

  this.NewNode = function NewNode(val) {
    this.val = val;
    this.left = null;
    this.right = null;
  };

  this.printNode = function printNode(node) {
    console.log(node.val);
  };

  this.addNode = function addNode(val) {
    let node = new this.NewNode(val);
    // this.printNode(node);
    let currentNode = root;
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

  this.levelTraversal = function levelTraversal(printNode) {
    let queue = [root];
    let currentNode = root;
    while (queue) {
      currentNode = queue.shift();
      if (!currentNode) {
        return;
      }
      this.printNode(currentNode);
      if (currentNode.left) {
        queue.push(currentNode.left);
      }

      if (currentNode.right) {
        queue.push(currentNode.right);
      }
    }
  };
}

var newTree = new BST();
newTree.addNode(5);
newTree.addNode(3);
newTree.addNode(7);
newTree.addNode(2);
newTree.addNode(4);
newTree.addNode(6);
newTree.addNode(8);

newTree.levelTraversal();
