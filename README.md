# Sample Model-View-ViewModel (MVVM) WPF Applications

Developed for in-house MVVM trainings.

## 01 Simple View Model Binding

Demonstration of Model-View-ViewModel concepts and sample collection binding to ListView. There is also a simple value conversion sample for converting a DateTime value to String.

## 02 Command Binding

Demonstration of binding button actions to commands of View Model. Command is implemented as generic RelayCommand which takes delegates for "action to execute" and "can execute" check. There is also a utility class named MessageBoxHelper is added to the project. Although there is little benefit of using such an extra utility class for displaying message boxes, it should still be there, since it will be replaced with a service class in the dependency injection and testable architecture samples.