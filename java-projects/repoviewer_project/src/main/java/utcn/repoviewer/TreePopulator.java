
package utcn.repoviewer;

import java.io.File;
import javax.swing.tree.DefaultTreeModel;


public class TreePopulator {
    
    final String[] allowedFileTypes = new String[] {".java", ".xml", ".jpg", ".png"};

    private DefaultTreeModel treeModel;
    public TreePopulator(DefaultTreeModel treeModel){
        this.treeModel = treeModel;
    }
    
    public void populate(File fileRoot){
        FileNode rootNode = new FileNode(fileRoot);
        createChildren(fileRoot, rootNode);
        treeModel.setRoot(rootNode);
    }

    private boolean isFileVisible(File file){
        if (file.isDirectory()){
            if (file.getName().startsWith(".")) // .git and .idea folders are not shown
                return false;
            else
                return true;
        }
        for (String type: allowedFileTypes){
            if (file.getName().endsWith(type)) 
                return true;
        }
        return false;
    }

    private String createChildren(File fileRoot, FileNode node) {
        File[] files = fileRoot.listFiles();
        if (files == null) return null;

        String name = "";
        if(files.length == 1){
            File newFile = files[0];
            //Directory pass
            if(newFile.isDirectory()){
                name += "\\" + newFile.getName() + createChildren(newFile, node);
                node.setAlternativeName(newFile.getParentFile().getName() + name);
                return name;
            }
            node.add(new FileNode(newFile));
        }

        for (File file : files) {
            if (isFileVisible(file)){
                FileNode childNode = new FileNode(file);
                node.add(childNode);
                if (file.isDirectory()) {
                    createChildren(file, childNode);
                }
            }
        }
        return "";
    }
}