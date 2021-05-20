In order to use the unity project:

- Upon opening the project open the scene called MainScene inside the Scenes folder.

- On the left select the Cubes GameObject, then using the inpector you can adjust the Cube_spin component
  to set how many seconds a cube rotation lasts (0 is a stationary cube), you can also select the
  Static_45_degrees option to fix all cubes at a 45 degree angle about the y-axis.

- On the left select the Scene_Manager GameObject, then using the inspector you can use the Scene Manager
  Script component to select which problem you would like to view, as well as setting the radial distortion
  parameters for the LCA and pre-distortion correction. There is an optional inverse option to simulate
  passing through the lens as well. You can also select the triangle count for the mesh based pre-distortion.

- Unity scripts are in the Scipts folder and Shaders in the Shader folder:
  BarrelFrag is the pixel based pre-distortion
  BarrelVec is the mesh based pre-distortion
  ChromFrag is the LCA correction
  ChromInv is the inverse LCA correction
  Inv is the inverse pixel based pre-distortion
  InvVec is the inverse mesh based pre-distortion

