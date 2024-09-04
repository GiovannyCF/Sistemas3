import { PencilIcon, PlusCircleIcon, TrashIcon } from '@heroicons/react/20/solid';
import { NavLink } from 'react-router-dom';
import { Loading } from '../../../../assets/Loading';
import { EyeIcon } from '@heroicons/react/16/solid';
import { useSelector } from 'react-redux';
import { useEffect, useState } from 'react';
import { useRelease } from '../../../../hooks/useRelease';
export const ReleaseListPage = () => {
    const { releases, deleteRelease, getReleaes } = useRelease();
    const { isLoading, isLoadingDelete } = useSelector(state => state.globalStates);
    const [searchQuery, setSearchQuery] = useState('');

    useEffect(() => {
        getReleaes();
    }, [getReleaes]);
    const handleDelete = async (id) => {
        await deleteRelease(id);
    };

    const filteredReleases = releases.filter(release =>
        `${release.porcentaje} ${release.fecha}`.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return (
        <div className="container mx-auto p-6">
            <div className="text-center mb-8">
                <h2 className="text-3xl font-bold text-gray-700">Lista de Avances</h2>
            </div>
            <div className="flex flex-wrap gap-2 items-center justify-center md:justify-between mb-4 p-4 bg-white rounded-xl shadow-md border border-gray-300">
                {/* Contenedor de Botones y Buscador */}
                <div>
                    <NavLink to="/dashboard/registerRelease" className="flex items-center gap-x-2 rounded-md px-4 py-2 text-sm font-semibold shadow-sm text-white bg-blue-600 hover:bg-blue-700">
                        <PlusCircleIcon className="h-5 w-5" />Agregar
                    </NavLink>
                </div>
                {/* Buscador */}
                <div className="relative flex items-center max-w-sm">
                    <input
                        type="text"
                        placeholder="Buscar..."
                        onChange={(e) => setSearchQuery(e.target.value)}
                        className="pl-10 pr-4 py-2 w-full rounded-md border-0 text-gray-800 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-blue-500"
                    />
                    <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                        <svg className="h-5 w-5 text-gray-500" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 21l-4.35-4.35M10 4a6 6 0 106 6 6 6 0 00-6-6z"></path>
                        </svg>
                    </div>
                </div>
            </div>
            <div className="flex flex-col">
                {
                    isLoading ?
                        <div className='flex justify-center'>
                            <Loading />
                        </div>
                        :
                        <div className={`overflow-x-auto ${isLoadingDelete ? 'pb-4 blur-sm grayscale pointer-events-none' : ''}`}>
                            <div className="block">
                                <div className="overflow-x-auto w-full rounded-xl border border-gray-300 shadow-md">
                                    <table className="w-full rounded-xl bg-white">
                                        <thead>
                                            <tr className="bg-gray-100">
                                                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-800 uppercase tracking-wider">
                                                    Porcentaje
                                                </th>
                                                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-800 uppercase tracking-wider">
                                                    Fecha
                                                </th>
                                                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-800 uppercase tracking-wider">
                                                    Tarea
                                                </th>
                                                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-800 uppercase tracking-wider">
                                                    Acciones
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody className="divide-y divide-gray-200">
                                            {
                                                filteredReleases.map((release) => (
                                                    <tr key={release.id}>
                                                        <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{release.porcentaje}%</td>
                                                        <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{release.fecha}</td>
                                                        <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{release.tarea?.descripcion}</td>
                                                        <td className="px-6 py-4 text-sm font-medium text-gray-500">
                                                            <div className='flex space-x-2'>
                                                                <NavLink to={`../detailRelease/${release.id}`} className="text-blue-600 hover:text-blue-900">
                                                                    <EyeIcon className="w-5 h-5" />
                                                                </NavLink>
                                                                <NavLink to={`../editRelease/${release.id}`} className="text-yellow-600 hover:text-yellow-900">
                                                                    <PencilIcon className="w-5 h-5" />
                                                                </NavLink>
                                                                <button
                                                                    onClick={() => handleDelete(release.id)}
                                                                    className="text-red-600 hover:text-red-900"
                                                                >
                                                                    <TrashIcon className="w-5 h-5" />
                                                                </button>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                ))
                                            }
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                }
            </div>
        </div>
    )
}
