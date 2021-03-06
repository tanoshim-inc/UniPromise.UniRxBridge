﻿using UnityEngine;
using UniRx;
using System.Collections.Generic;
using System;

namespace UniPromise.UniRxBridge {
	public static class AddToPromiseExtensions {
		public static Promise<T> AddPromiseTo<T>(this Promise<T> promise, ICollection<IDisposable> container) where T : class {
			return AddTo (promise, container);
		}

		public static Promise<T> AddTo<T>(this Promise<T> promise, ICollection<IDisposable> container) where T : class {
			if (promise.IsPending) {
				UniRx.DisposableExtensions.AddTo (promise, container);
				promise.Finally (() => container.Remove (promise));
			}

			return promise;
		}

		public static Promise<T> AddTo<T>(this Promise<T> promise, GameObject gameObject) where T : class {
			if(promise.IsPending)
				UniRx.DisposableExtensions.AddTo(promise, gameObject);

			return promise;
		}
		
		public static Promise<T> AddTo<T>(this Promise<T> promise, Component component) where T : class {
			if(promise.IsPending)
				UniRx.DisposableExtensions.AddTo(promise, component);

			return promise;
		}
	}
}
