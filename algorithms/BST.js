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

  this.findMin = function findMin() {
    let currentNode = root;
    if (!currentNode) {
      while(!currentNode.left) {
        currentNode = currentNode.left;
      }
      console.log(currentNode.val);
      return currentNode;
    }
    return null;
  };

  this.findMax = function findMax() {
    let currentNode = root;
    if (!currentNode) {
      while(!currentNode.right) {
        currentNode = currentNode.right;
      }
      console.log(currentNode.val);
      return currentNode;
    }
    return null;
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

  // Currently only works if target node has no children
  this.removeNode = function removeNode(val) {
    let queue = [root];
    let currentNode = root;
    let parentNode = root;
    while (queue) {
      currentNode = queue.shift();
      if (!currentNode) {
        return; 
      }
      if (currentNode.left && currentNode.right) {
        if (currentNode.left.val == val || currentNode.right.val == val) {
          parentNode = currentNode;
          this.printNode(parentNode);
        }
      }
      if (currentNode.val == val) {
        if (!currentNode.left && !currentNode.right) {
          if (val > parentNode.left.val) {
            parentNode.right = null;
          }
          else {
            parentNode.left = null;
          }
        }
      }
      else {
        if (currentNode.left) {
          queue.push(currentNode.left);
        }
        if (currentNode.right) {
          queue.push(currentNode.right);
        }
      }
    }
  };

  // Recursive version of remove
  this.deleteNode = function deleteNote(val, node) {
    let currentNode = root;
    if (!currentNode) {
      console.log("No root");
      return;
    }
    else if (val < currentNode.val) {
      currentNode.left = this.deleteNode(val, currentNode.left);
    }
    else if (val > currentNode.val) {
      currentNode.right = this.deleteNode(val, currentNode.right);
    }
    else {
      if (currentNode.left && currentNode.right) {
        let leftMax = this.findMin(currentNode.left);
        currentNode = leftMax;
        currentNode.left = this.deleteNode(currentNode.left, val);
      }
      else {
        if (!currentNode.left && !currentNode.right) {
          currentNode = null;
          return;
        }
        else if (!currentNode.left) {
          currentNode = currentNode.right;
        }
        else if (!currentNode.right) {
          currentNode = currentNode.left;
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
