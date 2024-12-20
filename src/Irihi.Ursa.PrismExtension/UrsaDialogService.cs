﻿using System.Threading.Tasks;
using Avalonia.Controls;
using Prism.Ioc;
using Ursa.Controls;

namespace Ursa.PrismExtension;

public class UrsaDialogService(IContainerExtension container) : IUrsaDialogService
{
    public void ShowCustom(string viewName, object? vm, Window? owner = null, DialogOptions? options = null)
    {
        var v = container.Resolve<Control>(UrsaDialogServiceExtension.UrsaDialogViewPrefix + viewName);
        Ursa.Controls.Dialog.ShowCustom(v, vm, owner, options);
    }

    public Task<Ursa.Controls.DialogResult> ShowModal(string viewName, object? vm, Window? owner = null,
        DialogOptions? options = null)
    {
        var v = container.Resolve<Control>(UrsaDialogServiceExtension.UrsaDialogViewPrefix + viewName);
        return Ursa.Controls.Dialog.ShowModal(v, vm, owner, options);
    }

    public Task<TResult?> ShowCustomModal<TResult>(string viewName, object? vm, Window? owner = null,
        DialogOptions? options = null)
    {
        var v = container.Resolve<Control>(UrsaDialogServiceExtension.UrsaDialogViewPrefix + viewName);
        return Ursa.Controls.Dialog.ShowCustomModal<TResult>(v, vm, owner, options);
    }
}